using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Domain.Common
{
    /*
     * Her entity'nin 
     *    -- bir id'si olacak
     *       fakat bu id'nin tipi her entity için farklı olabilir
     *       bu yüzden generic bir BaseEntity sınıfı oluşturuyoruz
     *       
     *    -- bir oluşturulma tarihi olacak
     *    -- gerekirse güncellenme tarihi olacak"
     *    
     */
    public abstract class BaseEntity<TID> : IEntity where TID: struct, IEquatable<TID>
    {
        public TID Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public BaseEntity()
        {
            Id =  Id is Guid ? (TID)(object)Guid.NewGuid() : default;
            CreatedAt = DateTime.Now;

        }


        //equals ve gethashcode metotlarını override ediyoruz
        //çünkü entity'lerin referans eşitliği yerine içerik eşitliğine bakılmasını istiyoruz


        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is BaseEntity<TID>))
                return false;
            return this.Id.Equals(((BaseEntity<TID>)obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(BaseEntity<TID> a, BaseEntity<TID> b)
        {
            if (a is null && b is null)
                return true;
            if (a is null || b is null)
                return false;
            return a.Id.Equals(b.Id);
        }

        public static bool operator !=(BaseEntity<TID> a, BaseEntity<TID> b)
        {
            return !(a == b);
        }


    }
}
