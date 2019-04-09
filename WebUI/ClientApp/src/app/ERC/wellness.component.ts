import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
    selector: 'ERC',
  templateUrl: './wellness.component.html',
  styleUrls: ['./wellness.component.css']
})
export class WellnessComponent {
  public Articles: article[];
  safeSrc: SafeResourceUrl;


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private sanitizer: DomSanitizer) {
    http.get<article[]>(baseUrl + 'api/Articles/17').subscribe(result => {
      this.Articles = result;
    }, error => console.error(error));
    this.safeSrc =  this.sanitizer.bypassSecurityTrustResourceUrl("https://www.youtube.com/embed/4iegZDvPajo");
  }
}

interface article {
  Id: number;
    Title: string;
    ArticleUrl: string;
    Article_text: string;
}