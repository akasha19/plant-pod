using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PlantPodService.Model
{
    public class PlantEntityConfiguration : IEntityTypeConfiguration<PlantEntity>
    {
        public void Configure(EntityTypeBuilder<PlantEntity> builder)
        {
            builder.HasData(Plants());
        }

        private static PlantEntity[] Plants() => 
            new[] {
                new PlantEntity {
                    Id = Guid.Parse("39cbdff3-1ea6-44a6-9129-f1f5e9cb6c18"),
                    LongName = "Musa Ornata",
                    ShortName = "Banana Tree",
                    Description = "Musa ornata, the flowering banana, is one of more than 50 species of banana in the genus Musa of the family Musaceae. Most of these species are large tropical evergreen perennials, mainly from lowland areas with high temperature and humidity. Musa ornata originated in southeast Asia, and is cultivated for its commercial and ornamental value. The fruit is attractive but tends to be inedible. Banana Plants are best equipped for locations that provide bright, indirect light. Areas that are too dark will significantly increase the risk of root rot, along with slowed growth and yellowing older leaves.\nAllow the top half to dry out in between waters, reducing this further in the autumn and winter. Over-watering during its dormancy period is a common issue among owners, so always bear this in mind when the colder months arrive.\nFertilise using a 'Houseplant' labeled feed every four waters in the spring and summer, reducing this to every six in the colder months.\nKeep an eye out for Spider Mites that'll form webs on the under-sides of its foliage. Aphids can also attack the juvenile growth once the temperatures start to increase in the spring.\nEspecially if located in a dark location, wash or dust the foliage monthly, to increase the light-capturing efficiency.\nRepot every two or three years using 'Cactus & Succulent' soil. Introduce a layer of grit for larger specimens to strengthen their root system and downplay over-watering.",
                    Care = "Banana plants are have a relatively high hardiness zone, but an occasional frost will kill them. When keeping a banana plant at home, it needs to be kept relatively warm. Any temperature under 15 degrees celsius may badly influence the health and growth of the plant.",
                    MinTemperature = 27m,
                    MaxTemperature = 35m,
                    Minph = 5.5m,
                    Maxph = 6.5m,
                    MinHumidity = 50m,
                    MaxHumidity = 100m,
                    Image = "assets/img/bananaplant.jpg",
                    Moisture = Moisture.Moist
                },
                new PlantEntity {
                    Id = Guid.Parse("8926930f-d571-466f-8ca5-bfa3d8cf28c3"),
                    LongName = "Zamicioculcas zamiifolia",
                    ShortName = "ZZ Plant",
                    Description = "This plant is a herbaceous perennial growing to 45–60 centimeters tall, from a stout underground. It is normally evergreen, will shed its leaves during drought, surviving drought due to the large potato-like rhizome that stores water until rainfall resumes. The leaves are pinnate, 40–60 centimeters long, with 6–8 pairs of leaflets 7–15 centimeters long; they are smooth, shiny, and dark green. The stems of these pinnate leaves are thickened at the bottom. The flowers are produced in a small bright yellow to brown or bronze spadix 5–7 centimeters long, partly hidden among the leaf bases; flowering is from mid summer to early autumn. Zamioculcas zamiifolia contains an unusually high water contents of leaves (91%) and petioles (95%) and has an individual leaf longevity of at least six months, which may be the reason it can survive extremely well under interior low light levels for four months without water.",
                    Care = "This tropical perennial plant tolerates drought and significant levels of neglect, accepting low-light conditions without much fuss. It is one of the most common house plants across the world, even if it is native to Africa. As long as you do not expose it to direct, powerful sunlight and you take minimum care of it, you should enjoy it for years",
                    MinTemperature = 15m,
                    MaxTemperature = 24m,
                    Minph = 6m,
                    Maxph = 7m,
                    MinHumidity = 35m,
                    MaxHumidity = 45m,
                    Image = "assets/img/zzplant.jpg",
                    Moisture = Moisture.Dry
                },
                new PlantEntity {
                    Id = Guid.Parse("79924374-44ad-4f9f-938b-6ac89e7ec60c"),
                    LongName = "Aloe Vera",
                    ShortName = "Aloe vera",
                    Description = "Aloe vera, sometimes described as a “wonder plant,” is a short-stemmed shrub. Aloe is a genus that contains more than 500 species of flowering succulent plants. Many Aloes occur naturally in North Africa. The leaves of Aloe vera are succulent, erect, and form a dense rosette. Many uses are made of the gel obtained from the plant’s leaves.",
                    Care = "Aloe vera are succulents, so they store water in their leaves. It is important not to over-water them – water whenever the top few centimeters of compost to dry out between watering. Make sure you let the water drain away fully – do not let the plant sit in water as this may cause the roots to rot. Aloes need very little water in winter. Aloes are slow growing so repot when the plant has outgrown its pot, usually every two or three years. Feed every couple of months from April to September with a weak plant food. Wipe the leaves occasionally, to prevent dust building up. ",
                    MinTemperature = 13m,
                    MaxTemperature = 27m,
                    Minph = 7m,
                    Maxph = 8.5m,
                    MinHumidity = 10m,
                    MaxHumidity = 70m,
                    Image = "assets/img/aloevera.jpg",
                    Moisture = Moisture.Normal
                },
                new PlantEntity {
                    Id = Guid.Parse("68fb0a91-21ca-43c9-abca-8eccd022f7d6"),
                    LongName = "Dracaena sanderiana",
                    ShortName = "Lucky Bamboo",
                    Description = "The Lucky Bamboo is a flowering plant growing in water and also one of the most common houseplants. Many people think that it’s a real bamboo plant. But it is a type of tropical water lily called Dracaena Sanderiana. The lucky bamboo plant is one of the most popular Feng Shui cures said to bring good luck and prosperity to the place where it is grown. It is also known to enhance the flow of positive energy in the home and office when placed in the right direction. The lucky bamboo plant represents the element wood and the red ribbon tied around it represents the element fire. It is known to create the sense of balance and safety in life. Get  one for yourself or offer it as a gift for someone you care about. The Lucky Bamboo symbolizes a rich life, full of prosperity and strength, and we all need some of that these days.",
                    Care = "Lucky bamboo is an easy plant to care for which makes it great for offices and homes alike. It’s happy growing in soil or water but has the longest life when grown in soil. Because it’s a Dracaena, lucky bamboo care is more in line with Dracaena care as opposed to bamboo. If growing in water, it should be replaced every week. If planted in soil, the soil should be kept slightly damp, so don’t over-water or let it get  dry. Lucky bamboo does best in indirect light.",
                    MinTemperature = 18m,
                    MaxTemperature = 35m,
                    Minph = 6m,
                    Maxph = 6.5m,
                    MinHumidity = 50m,
                    MaxHumidity = 100m,
                    Image = "assets/img/luckybamboo.jpg",
                    Moisture = Moisture.Wet
                },
                new PlantEntity {
                    Id = Guid.Parse("0ef97408-0dac-46cf-aba1-d07235992bdd"),
                    LongName = "Pilea peperomioides",
                    ShortName = "Pancake Plant",
                    Description = "With its undeniably unique look, pancake plants (Pilea peperomioides) come with their own rich history. Also called a Chinese money plant, coin plant, or missionary plant, this trendy species is an easy-care houseplant with flat, round, succulent leaves. Long cultivated in China, this plant was brought to Europe by a Norwegian missionary in the 1940s. Pancake plants are known as the \"Pass It On\" plant thanks to many years of being gifted between friends around the globe.",
                    Care = "With the right soil—high-quality, organic potting soil with peat moss or coir fiber base—and bright, indirect light, pancake plants are easy to grow. Allow the soil to dry out between watering, and avoid letting these plants sit in water. Always water from the top rather than allowing pancake plants to soak up water from the bottom. Feed your pancake plant monthly doses of liquid houseplant fertilizer diluted to half-strength during spring and summer. If you're not seeing baby plants, make sure you're fertilizing, pinching off dead growth, and giving your plant sufficient light. \n\nIf your plant is tall and top-heavy, trim off the top portion to propagate on its own; this can spur new growth and offsets in the mother plant. For a fuller-looking plant, simply leave the offsets in the soil or on the stem (removing them only to encourage growth).",
                    MinTemperature = 13m,
                    MaxTemperature = 30m,
                    Minph = 6m,
                    Maxph = 7m,
                    MinHumidity = 50m,
                    MaxHumidity = 75m,
                    Image = "assets/img/pancakeplant.jpg",
                    Moisture = Moisture.Normal
                }
            };
    }
}
