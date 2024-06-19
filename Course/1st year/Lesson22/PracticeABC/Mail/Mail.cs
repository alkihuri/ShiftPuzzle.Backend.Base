namespace Mail;

public class Mail
{
    public Mail(string email)
    {
        Email = email;
        Letters = new List<Letter>();
    }
    
    public string Email { get; set; }
    
    public List<Letter> Letters { get; set; }

    public void CreateRandomLetters(int count)
    {
        var currentCount = Letters.Count;
        
        for (int i = currentCount; i < currentCount + count; i++)
        {
            Letters.Add(new Letter
            {
                Id = i,
                Title = $"Title {i}",
                Body = $"Body {i}",
                IsNew = i % 2 == 0,
                Received = DateTime.Now.AddMinutes(i % 2 > 0 ? i : -i)
            });
        }
    }
    
    public List<int> GetNewLetterIds_Classic()
    {
        var res = new List<int>();
        for(int i = 0; i < Letters.Count; i++)
        {
            if (Letters[i].IsNew)
                res.Add(Letters[i].Id);
        }
        return res;
    }
    
    public List<int> GetNewLetterIds_Linq()
    {
        // TODO: Задание 1. напишите здесь linq запрос
        throw new NotImplementedException(); // заглушка, надо убрать
    }
    
    public void SortByRecived_Classic()
    {
        for (int i = 0; i < Letters.Count - 1; i++)
        {
            for (int j = i + 1; j < Letters.Count; j++)
            {
                if (Letters[i].Received > Letters[j].Received)
                {
                    Letter temp = Letters[i];
                    Letters[i] = Letters[j];
                    Letters[j] = temp;
                }
            }
        }
    }
    
    public void SortByRecived_Linq()
    {
        // TODO: Задание 2. напишите здесь linq запрос
        throw new NotImplementedException(); // заглушка, надо убрать
    }
}