import { Component, OnInit } from '@angular/core';
import { HeaderService } from '../_services';
@Component({
  selector: 'app-header',
  templateUrl: 'header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {
  title;
  constructor(private headerService: HeaderService) { }
  ngOnInit() {
    this.headerService.title.subscribe(title => {
      this.title = title;
    });

  }
}
