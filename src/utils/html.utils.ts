import cheerio from "cheerio";

//https://stackoverflow.com/a/28653405
const findTextAndReturnRemainder = (
  target: string,
  variable: string
): string => {
  var chopFront = target.substring(
    target.search(variable) + variable.length,
    target.length
  );
  var result = chopFront.substring(0, chopFront.search(";"));
  return result;
};

export const getJavascriptVariable = (
  page: string,
  varName: string,
  varType: "const" | "let" | "var"
): string => {
  const parsed = cheerio.load(page);
  //const text = parsed(parsed("script")).text();
  const variable = `${varType} ${varName} =`;
  const text = parsed(`script:contains("${variable}")`).toString();
  console.log(text);
  return findTextAndReturnRemainder(text, variable);
};
