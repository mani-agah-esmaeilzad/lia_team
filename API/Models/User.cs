namespace API.Models;
public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("name")]
    public string Name { get; set; }
    [BsonElement("lastname")]
    public string LastName { get; set; }
    [BsonElement("number")]
    public string Number { get; set; }
    [BsonElement("address")]
    public string Address { get; set; }
    [BsonElement("role")]
    public string Role { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
}
