import { SearchEngineType } from "../enums/search-engine-type.enum";

export interface GetSEOIndexesQuery {
  keyword?: string;
  targetWebsite?: string;
  searchEngineType: SearchEngineType;
}
