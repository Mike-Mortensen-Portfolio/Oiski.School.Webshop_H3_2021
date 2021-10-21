using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oiski.School.Webshop_H3_2021.Servicelayer.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Maps all properties of <paramref name="_type"/> to a <see cref="TypeDTO"/>
        /// </summary>
        /// <param name="_type"></param>
        /// <returns>The mapped <see cref="TypeDTO"/> if <paramref name="_type"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static TypeDTO MapSingleToBaseDTO(this Datalayer.Entities.Type _type)
        {
            if (_type == null) return null;

            return new TypeDTO
            {
                Name = _type.Name,
                TypeID = _type.TypeID
            };
        }

        /// <summary>
        /// Maps a collection of <see cref="Datalayer.Entities.Type"/> <see langword="objects"/> to an <see cref="IQueryable{T}"/> <see langword="object"/> of type <see cref="Datalayer.Entities.Type"/>
        /// </summary>
        /// <param name="_types"></param>
        /// <returns>The mapped <see cref="IQueryable{T}"/> of type <see cref="TypeDTO"/> if <paramref name="_types"/> is not <see langword="null"/>. Otherwise returns <see langword="null"/></returns>
        public static ICollection<TypeDTO> ConvertToDTOList(this ICollection<Datalayer.Entities.Type> _types)
        {
            if (_types == null) return null;

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
