import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-validation-error-message',
  templateUrl: './validation-error-message.component.html',
  styleUrls: ['./validation-error-message.component.css']
})
export class ValidationErrorMessageComponent implements OnInit {

  @Input()
  textMessage:string;

  @Input()
  formControl: FormControl;

  constructor() { }

  ngOnInit() {
  }

}
