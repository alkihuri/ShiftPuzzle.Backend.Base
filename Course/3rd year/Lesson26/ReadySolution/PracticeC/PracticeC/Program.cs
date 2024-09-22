using System.Data.SQLite;

class Program
{
    static async Task Main()
    {
        int[] seatIds = { 1, 2, 3, 3, 5 }; // Примеры идентификаторов мест для резервирования

        // Запуск нескольких асинхронных задач резервирования для создания конкуренции
        Task[] tasks = new Task[seatIds.Length];
        for (int i = 0; i < seatIds.Length; i++)
        {
            int seatId = seatIds[i];
            tasks[i] = Task.Run(() => ReserveSeatAsync(seatId));
        }

        await Task.WhenAll(tasks); // Дождаться завершения всех задач
    }

    static async Task ReserveSeatAsync(int seatId)
    {
        string connectionString = "Data Source=sqlite.db;Version=3;";
        int maxRetries = 3; // Максимальное количество повторных попыток
        int retries = 0; // Текущий счетчик попыток
        bool success = false;

        using (var conn = new SQLiteConnection(connectionString))
        {
            while (retries < maxRetries && !success)
            {
                try
                {
                    await conn.OpenAsync();
                    using (var transaction = conn.BeginTransaction())
                    {
                        var command = conn.CreateCommand();
                        command.Transaction = transaction;

                        // Проверка наличия свободного места
                        command.CommandText = "SELECT * FROM Seats WHERE seat_id = @seat_id AND is_reserved = 0;";
                        command.Parameters.AddWithValue("@seat_id", seatId);
                        var reader = await command.ExecuteReaderAsync();

                        if (!reader.HasRows)
                        {
                            throw new Exception("Место уже забронировано или не существует.");
                        }

                        reader.Close();

                        // Обновление статуса места
                        command.CommandText = "UPDATE Seats SET is_reserved = 1 WHERE seat_id = @seat_id;";
                        await command.ExecuteNonQueryAsync();

                        // Добавление записи о резервации
                        command.CommandText =
                            "INSERT INTO Reservations (seat_id, reserved_at) VALUES (@seat_id, CURRENT_TIMESTAMP);";
                        await command.ExecuteNonQueryAsync();

                        // Логгирование успешной попытки
                        command.CommandText =
                            "INSERT INTO ReservationAttempts (seat_id, attempt_time, status) VALUES (@seat_id, CURRENT_TIMESTAMP, 'SUCCESS');";
                        await command.ExecuteNonQueryAsync();

                        // Завершение транзакции
                        transaction.Commit();
                        success = true;
                        Console.WriteLine($"Место {seatId} успешно забронировано.");
                    }
                }
                catch (SQLiteException ex)
                {
                    if (ex.ResultCode == SQLiteErrorCode.Busy || ex.ResultCode == SQLiteErrorCode.Locked)
                    {
                        retries++;
                        Console.WriteLine(
                            $"Попытка {retries} резервирования места {seatId} не удалась из-за блокировки: {ex.Message}");

                        // Логгирование неуспешной попытки
                        await LogFailureAsync(conn, seatId, ex.Message);

                        await Task.Delay(1000); // Задержка перед повторной попыткой
                    }
                    else
                    {
                        Console.WriteLine($"Ошибка при резервировании места {seatId}: {ex.Message}");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при резервировании места {seatId}: {ex.Message}");
                    break;
                }
                finally
                {
                    conn.Close();
                }
            }

            if (!success)
            {
                Console.WriteLine($"Не удалось забронировать место {seatId} после {maxRetries} попыток.");
            }
        }
    }

    static async Task LogFailureAsync(SQLiteConnection conn, int seatId, string error)
    {
        try
        {
            await conn.OpenAsync();
            using (var command = conn.CreateCommand())
            {
                command.CommandText =
                    "INSERT INTO ReservationAttempts (seat_id, attempt_time, status, error) VALUES (@seat_id, CURRENT_TIMESTAMP, 'FAILURE', @error);";
                command.Parameters.AddWithValue("@seat_id", seatId);
                command.Parameters.AddWithValue("@error", error);
                await command.ExecuteNonQueryAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при логгировании: {ex.Message}");
        }
    }
}