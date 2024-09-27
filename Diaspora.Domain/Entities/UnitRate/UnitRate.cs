using Diaspora.Domain.Exceptions;
using Diaspora.Domain.Shared.Enums;
using Diaspora.Domain.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diaspora.Domain.Entities.UnitTariff
{
    public class UnitRate
    {
        public UnitRateId Id { get; set; }

        public CityId OriginCityId { get; set; }

        public CityId DestinationCityId { get; set; }

        public ServiceTypeId ServiceTypeId { get; set; }

        public UnitPrice UnitPrice { get; set; }

        public bool IsActive { get; set; }

        public AuditInfo AuditInfo { get; set; }

        private UnitRate(UnitRateId id, CityId originCityId, CityId destinationCityId, ServiceTypeId serviceTypeId, UnitPrice unitPrice, bool isActive, AuditInfo auditInfo)
        {
            Id = id;
            OriginCityId = originCityId;
            DestinationCityId = destinationCityId;
            ServiceTypeId = serviceTypeId;
            UnitPrice = unitPrice;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        private UnitRate(CityId originCityId, CityId destination, ServiceTypeId serviceTypeId, UnitPrice unitPrice, bool isActive, AuditInfo auditInfo)
        {
            OriginCityId = originCityId;
            DestinationCityId = destination;
            ServiceTypeId = serviceTypeId;
            UnitPrice = unitPrice;
            IsActive = isActive;
            AuditInfo = auditInfo;
        }

        public static UnitRate Create(int origin, int destination, int serviceType, decimal unitPrice, DateTime createdAt, int createdBy)
        {
            var originCityId = CityId.Create(origin);
            var destinationCityId = CityId.Create(destination);
            var serviceTypeId = ServiceTypeId.Create(serviceType);
            var unitPriceValue = UnitPrice.Create(unitPrice);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, createdAt, createdBy);
            return new UnitRate(originCityId, destinationCityId, serviceTypeId, unitPriceValue, true, auditInfo);
        }

        public static UnitRate FromPrimitives(int id, int origin, int destination, int serviceType, decimal unitPrice, bool isActive, DateTime createdAt, int createdBy, DateTime updatedAt, int updatedBy)
        {
            var originCityId = CityId.Create(origin);
            var destinationCityId = CityId.Create(destination);
            var serviceTypeId = ServiceTypeId.Create(serviceType);
            var unitPriceValue = UnitPrice.Create(unitPrice);
            var auditInfo = AuditInfo.Create(createdAt, createdBy, updatedAt, updatedBy);
            var unitTariffId = new UnitRateId(id);
            return new UnitRate(unitTariffId, originCityId, destinationCityId, serviceTypeId, unitPriceValue, isActive, auditInfo);
        }

        private readonly int MinilDeclaredPlainValue = 200;
        private readonly decimal ImportDutiesCharge = 0.8m;
        private readonly int DiscountUnit = 1;
        private readonly string NegativeDeclaredValueExceptionLabel = "declared value";
        private readonly string NegativeWeightExceptionLabel = "weight";


        public decimal CalculatePrice(decimal weight)
        {
            if (weight <= 0)
            {
                throw ArgumentNegativeException.ForParameter(NegativeWeightExceptionLabel, weight);
            }

            decimal unitPrice = UnitPrice.Value;
            decimal totalPrice = unitPrice * weight;

            return weight switch
            {
                < (int)WeightDiscountGroupsEnum.Group1 => totalPrice,
                >= (int)WeightDiscountGroupsEnum.Group1 and < (int)WeightDiscountGroupsEnum.Group2 => totalPrice - ((int)DiscountGroupValueEnum.DiscountGroup1 * weight),
                >= (int)WeightDiscountGroupsEnum.Group2 and < (int)WeightDiscountGroupsEnum.Group3 => totalPrice - ((int)DiscountGroupValueEnum.DiscountGroup2 * weight),
                _ => totalPrice - ((int)DiscountGroupValueEnum.DiscountGroup3 * weight),
            };
        }

        public decimal CalculateImportDuties(decimal declaredValue)
        {
            if (declaredValue <= 0)
            {
                throw ArgumentNegativeException.ForParameter(NegativeDeclaredValueExceptionLabel, declaredValue);
            }

            if (declaredValue >= MinilDeclaredPlainValue)
            {
                return declaredValue * ImportDutiesCharge;
            }
            else
            {
                return 0;
            }
        }
    }
}
