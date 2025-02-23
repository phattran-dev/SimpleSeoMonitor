import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GetSEOIndexesQuery, } from '../../models/get-seo-indexes-query.model';
import { SearchEngineType } from '../../enums/search-engine-type.enum';

@Component({
  selector: 'app-search-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './search-form.component.html',
  styleUrls: ['./search-form.component.scss']
})
export class SearchFormComponent {
  @Output() search = new EventEmitter<GetSEOIndexesQuery>();

  searchForm: FormGroup;
  searchEngines = ['Google', 'Bing'];

  constructor(private fb: FormBuilder) {
    this.searchForm = this.fb.group({
      keyword: [''],
      url: [''],
      searchEngine: ['Google']
    });
  }

  onSubmit() {
    if (this.searchForm.valid) {
      const formValue = this.searchForm.value;
      const query: GetSEOIndexesQuery = {
        keyword: formValue.keyword || undefined,
        targetWebsite: formValue.url || undefined,
        searchEngineType: this.getSearchEngineType(formValue.searchEngine)
      };
      this.search.emit(query);
    }
  }

  private getSearchEngineType(searchEngine: string): SearchEngineType {
    switch (searchEngine) {
      case 'Google':
        return SearchEngineType.Google;
      case 'Bing':
        return SearchEngineType.Bing;
      default:
        return SearchEngineType.Google;
    }
  }
}