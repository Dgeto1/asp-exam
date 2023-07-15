namespace Tehnoforest.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Tehnoforest.Data.Models;

    public class ProductsEntityConfiguration : IEntityTypeConfiguration<Automower>, IEntityTypeConfiguration<Chainsaw>, IEntityTypeConfiguration<GardenTractor>, IEntityTypeConfiguration<GrassTrimmer>, IEntityTypeConfiguration<LawnMower>
    {
        public void Configure(EntityTypeBuilder<Automower> builder)
        {
            builder.HasData(this.GenerateAutomowers());

            builder
                .HasOne(a => a.User)
                .WithMany(u => u.Automowers)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(a => a.IsAvailable)
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<Chainsaw> builder)
        {
            builder.HasData(this.GenerateChainsaws());

            builder
                .HasOne(c => c.User)
                .WithMany(u => u.Chainsaws)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(c => c.IsAvailable)
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<GardenTractor> builder)
        {
            builder.HasData(this.GenerateGardenTractors());

            builder
                .HasOne(gt => gt.User)
                .WithMany(u => u.GardenTractors)
                .HasForeignKey(gt => gt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(gt =>gt.IsAvailable)
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<GrassTrimmer> builder)
        {
            builder.HasData(this.GenerateGrassTrimmers());

            builder
                .HasOne(gt => gt.User)
                .WithMany(u => u.GrassTrimmers)
                .HasForeignKey(gt => gt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(gt => gt.IsAvailable)
                .HasDefaultValue(true);
        }

        public void Configure(EntityTypeBuilder<LawnMower> builder)
        {
            builder.HasData(this.GenerateLawnMowers());
            builder
                .HasOne(lm => lm.User)
                .WithMany(u => u.LawnMowers)
                .HasForeignKey(lm => lm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(lm => lm.IsAvailable)
                .HasDefaultValue(true);
        }

        private Automower[] GenerateAutomowers()
        {
            ICollection<Automower> automowers = new HashSet<Automower>();

            Automower automower;
            automower = new Automower()
            {
                Id = 1,
                Model = "305",
                WorkingAreaCapacity = 600,
                MaximumSlopePerformance = 40,
                BoundaryType = "Wire",
                Description = "Husqvarna Automower® 305 се характеризира с компактен дизайн и е идеална за по-малки, комплексни градини с площ до 600 m2 като с лекота обработва склонове с наклон от 40%. Четирколесната платформа, заедно със систематичното управление на проходите осигурява ефективна работа, а функцията за тройно търсене улеснява намирането на най-бързия път до зарядната станция.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/robotic-mowers/photos/studio/h310-2059.webp?v=1f5ec561e00e823d&format=WEBP_LANDSCAPE_CONTAIN_MD",
                Price = 2460,
                Availability = 5
            };
            automowers.Add(automower);

            automower = new Automower()
            {
                Id = 2,
                Model = "315 Mark II",
                WorkingAreaCapacity = 1500,
                MaximumSlopePerformance = 40,
                BoundaryType = "Wire",
                Description = "Когато се грижите за тревни площи с площ до 1500 m2, роботизираната косачка Husqvarna Automower® 315 Mark II върши работата вместо вас. Компактната конструкция с 4 колела означава, че тя може да се справя с наклони с 40% наклон и да се насочва през тесни проходи. Когато работата е свършена, функцията за тройно търсене намира най-бързия път обратно до зарядната станция.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/robotic-mowers/photos/studio/h310-2059.webp?v=1f5ec561e00e823d&format=WEBP_LANDSCAPE_CONTAIN_MD",
                Price = 3850,
                Availability = 5
            };
            automowers.Add(automower);

            return automowers.ToArray();
        }

        private Chainsaw[] GenerateChainsaws()
        {
            ICollection<Chainsaw> chainsaws = new HashSet<Chainsaw>();

            Chainsaw chainsaw;
            chainsaw = new Chainsaw()
            {
                Id = 1,
                Model = "120 Mark II",
                Power = 2,
                CylinderDisplacement = 38,
                BarLength = 35,
                Description = "Лесен за ползване трион в хоби сегмента. Благодарение на достатъчния капацитет на рязане, трионът е подходящ за рязане на дърва за огрев, леко поваляне или подрязване. Има X-Torq® двигател за ниски емисии и Air Injection, който пази филтъра чист.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/chainsaws/photos/studio/h110-0522.webp?v=a56825c923296e8&format=WEBP_LANDSCAPE_CONTAIN_XL",
                Price = 455,
                Availability = 5
            };
            chainsaws.Add(chainsaw);

            return chainsaws.ToArray();
        }

        private GardenTractor[] GenerateGardenTractors()
        {
            ICollection<GardenTractor> tractors = new HashSet<GardenTractor>();

            GardenTractor tractor;
            tractor = new GardenTractor()
            {
                Id = 1,
                Model = "TS 138L",
                CylinderDisplacement = 452,
                NetPower = 9,
                CuttingWidth = 97,
                CuttingHeightMax = 102,
                CuttingHeightMin = 38,
                Description = "TS 138L е удобен трактор, идеален за собственици на малки и средни градини. Той е ефективен трактор със странично изхвърляне, интелигентен дизайн и ергономичност. TS 138L разполага с мощен двигател Husqvarna Series с без-чок старт, лостово управляема хидростатична трансмисия и ергономично кормило.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/garden-tractors/photos/studio/h310-2250.webp?v=7a7813db23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL",
                Price = 6399,
                Availability = 5
            };
            tractors.Add(tractor);

            return tractors.ToArray();
        }

        private GrassTrimmer[] GenerateGrassTrimmers()
        {
            ICollection<GrassTrimmer> trimmers = new HashSet<GrassTrimmer>();

            GrassTrimmer trimmer;
            trimmer = new GrassTrimmer()
            {
                Id = 1,
                Model = "535RX",
                Power = 2,
                CuttingWidth = 47,
                Description = "Husqvarna 535RX е нова моторна коса в клас 35 куб. см., с отлична ергономия, предвидена за продължително и интензивно натоварване и с достатъчно мощност, за постигане на първокласни резултати.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/husqvarna/brushcutters/photos/studio/h210-0364.webp?v=e58eac2723296e8&format=WEBP_LANDSCAPE_CONTAIN_XL",
                Price = 1115,
                Availability = 5
            };
            trimmers.Add(trimmer);

            return trimmers.ToArray();
        }

        private LawnMower[] GenerateLawnMowers()
        {
            ICollection<LawnMower> mowers = new HashSet<LawnMower>();

            LawnMower mower;
            mower = new LawnMower()
            {
                Id = 1,
                Model = "LC 247S",
                DriveSystem = "Самоход",
                WorkingAreaCapacity = 800,
                CuttingWidth = 47,
                Description = "Мощна самоходна бензинова косачка за трева. Създаването на подредена и добре подстригана трева е истинско удоволствие с тази самоходна косачка със събиране на тревата. Husqvarna LC 247S е удобна за използване, задвижвана от двигател Husqvarna. Тя разполага и с лесна настройка на височината на рязане, интуитивни контроли и лесна сгъваема дръжка за удобна работа и съхранение.",
                ImageUrl = "https://www-static-nw.husqvarna.com/-/images/aprimo/klippo/walk-behind-mowers/photos/studio/il-527596.webp?v=e7809c1a23296e8&format=WEBP_LANDSCAPE_CONTAIN_XL",
                Price = 1100,
                Availability = 5
            };
            mowers.Add(mower);

            return mowers.ToArray();
        }
    }
}
