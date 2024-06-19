namespace Mail;

public class Letter
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Тело письма
    /// </summary>
    public string Body { get; set; }
    
    /// <summary>
    /// Новое ли письмо
    /// </summary>
    public bool IsNew { get; set; }
    
    /// <summary>
    /// Во сколько письмо было получено
    /// </summary>
    public DateTime Received { get; set; }
}