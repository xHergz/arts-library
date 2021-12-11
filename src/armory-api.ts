import axios from "axios";
import cheerio from "cheerio";
import { isNil } from "lodash";
import { writeFileSync } from "fs";

import { StockItem } from "./types/arts.types";
import { getJavascriptVariable } from "./utils/html.utils";

export const getArmoryPriceHistory = async (/*item: StockItem*/): Promise<
  number[]
> => {
  const result = await axios.get("https://armory.aruarose.com/item/12000087");
  const labelsVar = getJavascriptVariable(result.data, "labels", "const");
  const dataVar = getJavascriptVariable(result.data, "data", "const");
  if (isNil(dataVar)) {
    return [];
  }
  console.log("Here", dataVar);
  const chartData = JSON.parse(dataVar);
  return [];
};
