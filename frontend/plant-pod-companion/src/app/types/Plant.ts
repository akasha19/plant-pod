import { MoistureLevel } from "../plantpedia-page/MoistureLevels";

export interface Plant {
    id: string;
    longName: string;
    shortName: string;
    description: string;
    minTemperature: number;
    maxTemperature: number;
    minph: number;
    maxph: number;
    care: string;
    minHumidity: number;
    maxHumidity: number;
    imageSource: string;
    moisture: MoistureLevel;
}
