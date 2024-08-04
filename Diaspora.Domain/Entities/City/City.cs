using Diaspora.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.City
{
    public class City
    {
        public CityId Id { get; set; }

        public CityName Name { get; set; } = null!;

        public ProvinceId ProvinceId { get; set; }

        public GeoNameId GeoNameId { get; set; }
        
        public bool IsActive { get; set; }
        public AuditInfo AuditInfo { get; set; }

        private City (CityId id, CityName name, ProvinceId provinceId, GeoNameId geoNameId, bool isActive, AuditInfo auditInfo)
        {
            Id = id;
            Name = name;
            ProvinceId = provinceId;
            GeoNameId = geoNameId;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private City(CityName name, ProvinceId provinceId, GeoNameId geoNameId, bool isActive, AuditInfo auditInfo)
        {
            Name = name;
            ProvinceId = provinceId;
            GeoNameId = geoNameId;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static City Create(string name, int provinceId, int geoNameId, bool isActive, DateTime createdAt, int createdBy)
        {
            var cityName = CityName.Create(name);
            var province = ProvinceId.Create(provinceId);
            var geoName = GeoNameId.Create(geoNameId);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new City(cityName, province, geoName, isActive, auditInfo);
        }

        public static City FromPrimitives(int id, string name, int provinceId, int geoNameId, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var cityId = new CityId(id);
            var cityName = CityName.Create(name);
            var province = ProvinceId.Create(provinceId);
            var geoName = GeoNameId.Create(geoNameId);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            return new City(cityId, cityName, province, geoName, isActive, auditInfo);
        }
    }
}
