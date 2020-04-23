import { EngineResult } from './EngineResult';

export interface SearchResult {
  searchWord: string;
  engineResults: EngineResult[];
  wordWinner: string;
}
