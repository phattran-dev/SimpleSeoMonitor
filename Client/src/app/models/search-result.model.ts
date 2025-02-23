import { SearchEngineType } from "../enums/search-engine-type.enum";

export interface SearchResult {
  searchEngineTypeName: string;
  positions: number[];
}