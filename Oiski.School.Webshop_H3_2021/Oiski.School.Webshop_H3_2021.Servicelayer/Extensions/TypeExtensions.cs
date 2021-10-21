using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class TypeExtensions
    {
        public static TypeDTO MapSingleToBaseDTO(this Datalayer.Entities.Type _type)
        {
            return new TypeDTO
            {
                Name = _type.Name,
                TypeID = _type.TypeID
            };
        }

        public static ICollection<TypeDTO> ConvertToDTOList(this ICollection<Datalayer.Entities.Type> _types)
        {
            return _types
                .Select(t => new TypeDTO
                {
                    Name = t.Name,
                    TypeID = t.TypeID
                })
                .ToList();
        }
    }
}
