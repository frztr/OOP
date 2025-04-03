
// using System.Numerics;
// using System.Reflection;
// using Microsoft.EntityFrameworkCore;
// using Newtonsoft.Json;

// public class AbstractRepository<K,
// InAddDto,InUpdateDto,InEntityDto,T> : IRepository<K, InAddDto,InUpdateDto,InEntityDto>
// where K : IComparable<K>
// where T : class, IEntity<K>
// where InAddDto : IDto
// where InUpdateDto : IUpdateDto<K>
// where InEntityDto : IDto
// {
//     protected AppDbContext db {get;set;}

//     public AbstractRepository(AppDbContext db){
//         this.db = db;
//     }
//     protected virtual IQueryable<T> Set { get => this.db.Set<T>();}

//     protected T EntityById(K id)
//     {
//         return Set.FirstOrDefault(x => x.Id.CompareTo(id) == 0);
//     }

//     public virtual IEnumerable<InEntityDto> GetAll()
//     {
//         return Set.Select(x => x.Cast<InEntityDto>());
//         // return db.Set<T>().Select(x => entityConverter.Convert(x));
//     }

//     public virtual InEntityDto GetById(K id)
//     {
//         return Set.ToList().FirstOrDefault(x => x.Id.CompareTo(id) == 0).Cast<InEntityDto>();
//         // return entityConverter.Convert(db.Set<T>().FirstOrDefault(x => x.Id.CompareTo(id) == 0));
//     }

//     public virtual void Add(InAddDto addDto)
//     {
//         db.Set<T>().Add(addDto.Cast<T>());
//         // db.Set<T>().Add(addConverter.Convert(addDto));
//         db.SaveChanges();
//     }

//     public virtual void Update(InUpdateDto updateDto)
//     {
//         T entity = EntityById(updateDto.Id);
//         T converted = updateDto.Cast<T>();

//         Type myType = entity.GetType();
//         IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
//         foreach (PropertyInfo prop in props)
//         {
//             object? propValue = prop.GetValue(converted);
//             if(propValue != null){
//                 prop.SetValue(entity,propValue);
//             }
//         }
//         db.SaveChanges();
//     }

//     public virtual void Delete(K id)
//     {
//         db.Set<T>().Remove(EntityById(id));
//         db.SaveChanges();
//     }
// }