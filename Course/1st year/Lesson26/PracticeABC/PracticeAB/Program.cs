/*
Пратика А:
Система уведомлений:
Создайте простую систему уведомлений, где пользователь может подписываться на различные события (например, "новое сообщение", "новый заказ" и т. д.) и получать уведомления при их возникновении.

 
Пратика Б:

Система обработки асинхронных событий в предыдщуем примере:
Создайте систему обработки асинхронных событий, где различные задачи выполняются параллельно. Реализуйте механизм подписки на события с возможностью асинхронного выполнения обработчиков событий.
*/

// система уведомлений  
using System;   
using System.Collections.Generic;



public  class NotificationSystem
{
    public event Action OnNewMessage;
    public event Action OnNewOrder; 
        
    public NotificationSystem()
    { 

    }
// данная обертка нужна для того чтобы вызвать событие, 
//т.к. напрямую вызвать событие нельзя изза того что  фукнция мейн в статическом классе
    public void NewMessage()
    {
        OnNewMessage?.Invoke();
    }
    public void NewOrder() 
    {
        OnNewOrder?.Invoke();
    }
}

public class Program
{
    static void Main()
    {
        NotificationSystem notificationSystem = new NotificationSystem();
        notificationSystem.OnNewMessage += TestNewMsg;
        notificationSystem.OnNewOrder += TestNewOreder;

        notificationSystem.NewMessage();
        notificationSystem.NewOrder();
 
        
    }
    public static async void TestNewMsg()
    {
       await TestNewMsgAsync();
    }
    public static async void TestNewOreder()
    {
        await TestNewOrederAsync();
    }

    public static async Task TestNewMsgAsync()
    {
        Console.WriteLine("New message async");
    }

    public static async Task TestNewOrederAsync()
    {
        Console.WriteLine("New oreder async");
    }
   
}   