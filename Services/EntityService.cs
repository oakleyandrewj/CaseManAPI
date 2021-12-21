using CaseManAPI.Models;

namespace CaseManAPI.Services;

public static class EntityService
{
    static List<Entity> Entitys {get;}
    static int nextId = 3;
    static EntityService()
    {
        Entitys = new List<Entity>
        {
            new Entity {Id = 1, Name = "Mr John Smith", IsIdChecked = false},
            new Entity {Id = 2, Name = "Ms Jane Doe", IsIdChecked = true}
        };
    }

    public static List<Entity> GetAll() => Entitys;

    public static Entity? Get(int Id) => Entitys.FirstOrDefault(p => p.Id == Id);

    public static void Add(Entity entity)
    {
        entity.Id = nextId++;
        Entitys.Add(entity);
    }
public static void Delete(int id)
{
    var entity = Get(id);
    if(entity is null)
    return;

    Entitys.Remove(entity);
}

public static void Update(Entity entity)
{
    var index = Entitys.FindIndex(p => p.Id == entity.Id);
    if(index == -1)
    return;

    Entitys[index] = entity;
}
}