using HaloEzAPI.Abstraction.Enum.HaloWars2;
using HaloEzAPI.Model.Response.MetaData.HaloWars2.Views;

namespace HaloEzAPI.Model.Response.MetaData.HaloWars2
{
    public abstract class HW2ApiItem<T> where T : BaseView
    {
        public int Id { get; set; }
        public ContentTypeEnum Type { get; set; }
        public T View { get; set; }
    }
}