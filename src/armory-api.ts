import axios from "axios";
import cheerio from "cheerio";
import { isEmpty, isNil } from "lodash";
import { writeFileSync } from "fs";

import { StockItem } from "./types/arts.types";
import { getJavascriptVariable } from "./utils/html.utils";
import { ArmoryPrice } from "./types/armory.types";
import { parse } from "date-fns";

export const getArmoryPriceHistory = async (/*item: StockItem*/): Promise<
    ArmoryPrice[] | null
> => {
    const result = await axios.get("https://armory.aruarose.com/item/12000087");
    const labelsVar = getJavascriptVariable(result.data, "labels", "const");
    const dataVar = getJavascriptVariable(result.data, "data", "const");
    if (isNil(dataVar) || isNil(labelsVar)) {
        return [];
    }
    const dates = labelsVar
        .trim()
        .replace(/\[|\]|\n|\'|\s/g, "")
        .split(",")
        .filter((date) => !isEmpty(date));
    const dataStr = dataVar.match(new RegExp(/(data: \[((.|\n|\r)*)\],)/g));
    const prices = isNil(dataStr)
        ? null
        : dataStr[0]
              .trim()
              .replace(/(data:)|\[|\]|\n|\s|\'/g, "")
              .split(",")
              .filter((price) => !isEmpty(price));
    console.log(dates, prices);
    if (isNil(dates) || isNil(prices)) {
        return null;
    }
    const formattedPrices: ArmoryPrice[] = [];
    for (let index = 0; index < prices.length; index++) {
        formattedPrices.push({
            averagePrice: parseInt(prices[index]),
            date: parse(dates[index], "dd/MM/yy", new Date()),
        });
    }
    console.log(formattedPrices);
    return formattedPrices;
};
