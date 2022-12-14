using FluentNHibernate.Mapping;

namespace lab2.Models
{
    public class BankDetail : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        // public virtual string City { get; set; }
        public virtual City City { get; set; }
        public virtual string TIN { get; set; }
        public virtual string SettlementAccount { get; set; }
        public virtual Provider Provider { get; set; }
    }

    public class BankDetailMap : ClassMap<BankDetail>
    {
        public BankDetailMap()
        {
            Table("bank_detail");
            Id(x => x.Id).GeneratedBy.Sequence("bank_detail_id_seq");
            Map(x => x.Name).Column("bank_name");
            References(x => x.City).Column("city");
            Map(x => x.TIN).Column("tin");
            Map(x => x.SettlementAccount).Column("settlement_account");
            References(x => x.Provider).NotFound.Ignore().Column("provider");
        }
    }
}