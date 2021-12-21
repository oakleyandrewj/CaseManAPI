using CaseManAPI.Models;

namespace CaseManAPI.Services;

public static class MatterService
{
    static List<Matter> Matters {get;}
    static int nextId = 3;
    static MatterService()
    {
        Matters = new List<Matter>
        {
            new Matter {Id = 1, Name = "Claimant v Devendant", IsOnlineCase = false},
            new Matter {Id = 2, Name = "Purchase of 100 Test Street", IsOnlineCase = true}
        };
    }

    public static List<Matter> GetAll() => Matters;

    public static Matter? Get(int Id) => Matters.FirstOrDefault(p => p.Id == Id);

    public static void Add(Matter matter)
    {
        matter.Id = nextId++;
        Matters.Add(matter);
    }
public static void Delete(int id)
{
    var matter = Get(id);
    if(matter is null)
    return;

    Matters.Remove(matter);
}

public static void Update(Matter matter)
{
    var index = Matters.FindIndex(p => p.Id == matter.Id);
    if(index == -1)
    return;

    Matters[index] = matter;
}
}