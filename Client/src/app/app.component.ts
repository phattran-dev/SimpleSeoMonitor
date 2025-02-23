import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchFormComponent } from './components/search-form/search-form.component';
import { ResultsTableComponent } from './components/results-table/results-table.component';
import { SearchResult } from './models/search-result.model';
import { SEOMonitorService } from './services/seo-monitor.service';
import { GetSEOIndexesQuery } from './models/get-seo-indexes-query.model';
import { SearchEngineType } from './enums/search-engine-type.enum';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, SearchFormComponent, ResultsTableComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  searchResults: SearchResult[] = [
  ];
  errorMessages = '';
  constructor(private seoMonitorService: SEOMonitorService) { }

  onSearch(query: GetSEOIndexesQuery) {
    this.errorMessages = '';
    this.searchResults = [];

    this.seoMonitorService.getSeoIndexes(query).subscribe({
      next: (response) => {
        if (response.isSuccess) {
          switch (query.searchEngineType) {
            case SearchEngineType.Google:
              this.searchResults = [{ searchEngineTypeName: "Google", positions: response.data }]
              break;

            case SearchEngineType.Bing:
              this.searchResults = [{ searchEngineTypeName: "Bing", positions: response.data }]
              break;
          }

        } else {
          this.errorMessages = response.errorMessages ?? '';
          console.log('API Error:', response.errorMessages);
        }
      },
      error: (error) => {
        this.errorMessages = error?.error?.errorMessages;
        console.log('Request failed:', error);
      }
    });
  }
}