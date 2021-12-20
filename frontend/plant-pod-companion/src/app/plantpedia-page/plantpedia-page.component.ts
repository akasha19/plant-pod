import { Component, OnInit } from '@angular/core';
import { MoistureLevel } from './MoistureLevels';
import { Plant } from './plant';

@Component({
  selector: 'app-plantpedia-page',
  templateUrl: './plantpedia-page.component.html',
  styleUrls: ['./plantpedia-page.component.scss']
})

export class PlantpediaPageComponent implements OnInit {

  plants: Plant[] | undefined;

  readonly maxTemperatureTooltip = "(Maximum Temperature) Too high temperatures and this plant could dry out and die. Try opening a window or turning down the heating. If the plant is in direct sunlight, try moving it to a less sunny area for some time.";
  readonly minTemperatureTooltip = "(Minimum Temperature) When the plant is too cold, it could damage the plant and eventually kill it. Too cold environments will also stop it from growing. Try putting the plant in a more sunny area, turning up the heating for some time, or closing a window.";
  readonly maxphTooltip = "(Maximum pH) Different plants require different soil acidity (pH) to grow healthily. A pH that is too high for the plant, could eventually kill the plant. Try adding a small amount of aluminium sulfate or elemental sulfur in order to lower the pH.";
  readonly minphTooltip = "(Minimum pH) Different plants require different soil acidity (pH) to grow healthily. A pH that is too low for the plant, could eventually kill the plant. Adding granulated limestone to the soil will help increase the pH of the soil.";
  readonly minHumidityTooltip = "(Minimum Relative Humidity) When the humidity is too low, the plant could dry out an eventually die. The humidity could be increased by using a humidifier or by placing a bowl filled with water on a heating source near the plant.";
  readonly maxHumidityTooltip = "(Maximum Relative Humidity) Too high relative humidity could lead to fungi or bacteria on the plant. Lowering the humidity can be done by using a dehumidifier, or opening a window on a dry day.";

  readonly moistureLevelTooltips: Map<MoistureLevel, string> = new Map<MoistureLevel, string>([
    [MoistureLevel.Dry, "Dry soil should not feel damp or wet in any way, only water the soil once every few weeks and make sure to have a flower pot with holes in the bottom in order to drain any excess water."],
    [MoistureLevel.Moist, "Moist soil should feel and look damp or wet when touched. The best way to keep this level of moisture is to have a draining plant pod which is placed inside a container filled with water. Make sure to always keep the container filled with water."],
    [MoistureLevel.Normal, "This level of moisture can be obtained by regularly watering the plant pot. Make sure to drain the excess water, but always keep the soil damp."],
    [MoistureLevel.Wet, "This level of moisture can be dangerous for a lot of plants as it provides an excellent environment for moulds and root rot but some plants thrive in this environment. Moist soil can be provided by having a closed plant pot which is regularly provided with fresh water."],
  ]);

  ngOnInit(): void {
    this.plants = [
      {
        id: "1",
        longName: "Musa Ornata",
        shortName: "Banana Tree",
        description: "Musa ornata, the flowering banana, is one of more than 50 species of banana in the genus Musa of the family Musaceae. Most of these species are large tropical evergreen perennials, mainly from lowland areas with high temperature and humidity. Musa ornata originated in southeast Asia, and is cultivated for its commercial and ornamental value. The fruit is attractive but tends to be inedible. Banana Plants are best equipped for locations that provide bright, indirect light. Areas that are too dark will significantly increase the risk of root rot, along with slowed growth and yellowing older leaves.\nAllow the top half to dry out in between waters, reducing this further in the autumn and winter. Over-watering during its dormancy period is a common issue among owners, so always bear this in mind when the colder months arrive.\nFertilise using a 'Houseplant' labelled feed every four waters in the spring and summer, reducing this to every six in the colder months.\nKeep an eye out for Spider Mites that'll form webs on the under-sides of its foliage. Aphids can also attack the juvenile growth once the temperatures start to increase in the spring.\nEspecially if located in a dark location, wash or dust the foliage monthly, to increase the light-capturing efficiency.\nRepot every two or three years using 'Cactus & Succulent' soil. Introduce a layer of grit for larger specimens to strengthen their root system and downplay over-watering.",
        care: "Banana plants are have a relatively high hardiness zone, but an occational frost will kill them. When keeping a banana plant at home, it needs to be kept relatively warm. Any temperature under 15 degrees celsius may badly influence the health and growth of the plant.",
        minTemperature: 27,
        maxTemperature: 35,
        minph: 5.5,
        maxph: 6.5,
        minHumidity: 50,
        maxHumidity: 100,
        imageSource: "assets/img/bananaplant.jpg",
        moisture: MoistureLevel.Moist
      },
      {
        id: "2",
        longName: "Zamicioculcas zamiifolia",
        shortName: "ZZ Plant",
        description: "This plant is a herbaceous perennial growing to 45–60 centimetres tall, from a stout underground. It is normally evergreen, will shed its leaves during drought, surviving drought due to the large potato-like rhizome that stores water until rainfall resumes. The leaves are pinnate, 40–60 centimetres long, with 6–8 pairs of leaflets 7–15 centimetres long; they are smooth, shiny, and dark green. The stems of these pinnate leaves are thickened at the bottom. The flowers are produced in a small bright yellow to brown or bronze spadix 5–7 centimetres long, partly hidden among the leaf bases; flowering is from mid summer to early autumn. Zamioculcas zamiifolia contains an unusually high water contents of leaves (91%) and petioles (95%) and has an individual leaf longevity of at least six months, which may be the reason it can survive extremely well under interior low light levels for four months without water.",
        care: "This tropical perennial plant tolerates drought and significant levels of neglect, accepting low-light conditions without much fuss. It is one of the most common house plants across the world, even if it is native to Africa. As long as you do not expose it to direct, powerful sunlight and you take minimum care of it, you should enjoy it for years",
        minTemperature: 15,
        maxTemperature: 24,
        minph: 6,
        maxph: 7,
        minHumidity: 35,
        maxHumidity: 45,
        imageSource: "assets/img/zzplant.jpg",
        moisture: MoistureLevel.Dry
      },
      {
        id: "3",
        longName: "Aloe Vera",
        shortName: "Aloe vera",
        description: "Aloe vera, sometimes described as a “wonder plant,” is a short-stemmed shrub. Aloe is a genus that contains more than 500 species of flowering succulent plants. Many Aloes occur naturally in North Africa. The leaves of Aloe vera are succulent, erect, and form a dense rosette. Many uses are made of the gel obtained from the plant’s leaves.",
        care: "Aloe vera are succulents, so they store water in their leaves. It is important not to overwater them – water whenever the top few centimetres of compost to dry out between waterings. Make sure you let the water drain away fully – do not let the plant sit in water as this may cause the roots to rot. Aloes need very little water in winter. Aloes are slow growing so repot when the plant has outgrown its pot, usually every two or three years. Feed every couple of months from April to September with a weak plant food. Wipe the leaves occasionally, to prevent dust building up. ",
        minTemperature: 13,
        maxTemperature: 27,
        minph: 7,
        maxph: 8.5,
        minHumidity: 10,
        maxHumidity: 70,
        imageSource: "assets/img/aloevera.jpg",
        moisture: MoistureLevel.Normal

      },
      {
        id: "4",
        longName: "Dracaena sanderiana",
        shortName: "Lucky Bamboo",
        description: "The Lucky Bamboo is a flowering plant growing in water and also one of the most common houseplants. Many people think that it’s a real bamboo plant. But it is a type of tropical water lily called Dracaena Sanderiana. The lucky bamboo plant is one of the most popular Feng Shui cures said to bring good luck and prosperity to the place where it is grown. It is also known to enhance the flow of positive energy in the home and office when placed in the right direction. The lucky bamboo plant represents the element wood and the red ribbon tied around it represents the element fire. It is known to create the sense of balance and safety in life. Get one for yourself or offer it as a gift for someone you care about. The Lucky Bamboo symbolizes a rich life, full of prosperity and strength, and we all need some of that these days.",
        care: "Lucky bamboo is an easy plant to care for which makes it great for offices and homes alike. It’s happy growing in soil or water but has the longest life when grown in soil. Because it’s a Dracaena, lucky bamboo care is more in line with Dracaena care as opposed to bamboo. If growing in water, it should be replaced every week. If planted in soil, the soil should be kept slightly damp, so don’t overwater or let it get dry. Lucky bamboo does best in indirect light.",
        minTemperature: 18,
        maxTemperature: 35,
        minph: 6,
        maxph: 6.5,
        minHumidity: 50,
        maxHumidity: 100,
        imageSource: "assets/img/luckybamboo.jpg",
        moisture: MoistureLevel.Wet

      },
      {
        id: "5",
        longName: "Pilea peperomioides",
        shortName: "Pancake Plant",
        description: "With its undeniably unique look, pancake plants (Pilea peperomioides) come with their own rich history. Also called a Chinese money plant, coin plant, or missionary plant, this trendy species is an easy-care houseplant with flat, round, succulent leaves. Long cultivated in China, this plant was brought to Europe by a Norwegian missionary in the 1940s. Pancake plants are known as the \"Pass It On\" plant thanks to many years of being gifted between friends around the globe.",
        care: "With the right soil—high-quality, organic potting soil with peat moss or coir fiber base—and bright, indirect light, pancake plants are easy to grow. Allow the soil to dry out between waterings, and avoid letting these plants sit in water. Always water from the top rather than allowing pancake plants to soak up water from the bottom. Feed your pancake plant monthly doses of liquid houseplant fertilizer diluted to half-strength during spring and summer. If you're not seeing baby plants, make sure you're fertilizing, pinching off dead growth, and giving your plant sufficient light. \n\nIf your plant is tall and top-heavy, trim off the top portion to propagate on its own; this can spur new growth and offsets in the mother plant. For a fuller-looking plant, simply leave the offsets in the soil or on the stem (removing them only to encourage growth).",
        minTemperature: 13,
        maxTemperature: 30,
        minph: 6,
        maxph: 7,
        minHumidity: 50,
        maxHumidity: 75,
        imageSource: "assets/img/pancakeplant.jpg",
        moisture: MoistureLevel.Normal

      }
    ]
  }
}
