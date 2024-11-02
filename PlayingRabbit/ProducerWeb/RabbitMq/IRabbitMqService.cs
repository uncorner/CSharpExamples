namespace ProducerWeb.RabbitMq;

public interface IRabbitMqService
{
    void SendMessage(object obj);
    void SendMessage(string message);
}
