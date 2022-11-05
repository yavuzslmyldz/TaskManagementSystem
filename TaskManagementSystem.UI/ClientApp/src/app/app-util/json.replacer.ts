export class JsonReplacer {

  replacer(key: any, value: any) {
    if (typeof value === "string") {
      if (value == "")
        return undefined;
    }
    return value;
  }
}
