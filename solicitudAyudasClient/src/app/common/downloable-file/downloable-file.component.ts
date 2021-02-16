import { Component, Input, OnInit } from '@angular/core';
import { DataService } from 'src/app/services/data.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-downloable-file',
  templateUrl: './downloable-file.component.html',
  styleUrls: ['./downloable-file.component.css']
})
export class DownloableFileComponent implements OnInit {

  @Input()
  fileName:string;

  @Input()
  fileId:number;
  
  @Input()
  fileSize:string

  @Input()
  contentType:string


  url:string;
  constructor(private dataService:DataService) { }

  download(){  
    this.dataService.Download(this.fileId).subscribe(file => {
      console.log(file);
      
      this.downLoadFile(file, this.contentType)
      
    })
  }

  downLoadFile(data: any, type: string) {
    let blob = new Blob([data], { type: type });
    let url = window.URL.createObjectURL(blob);
    let pwa = window.open(url);
    if (!pwa || pwa.closed || typeof pwa.closed == 'undefined') {
      alert('Please disable your Pop-up blocker and try again.');
    }
  }

  ngOnInit() {
  }

}
