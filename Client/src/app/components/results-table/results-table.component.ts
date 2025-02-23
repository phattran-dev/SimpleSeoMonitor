import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchResult } from '../../models/search-result.model';

@Component({
  selector: 'app-results-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './results-table.component.html',
  styleUrls: ['./results-table.component.scss']
})
export class ResultsTableComponent {
  @Input() results: SearchResult[] = [];
}