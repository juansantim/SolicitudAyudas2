import { Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

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

  @Input()
  formGroup: FormGroup;

  @Input()
  fieldName: string;

  @Input()
  errorName: string;

  ShowAnyWay: boolean;

  constructor() { }

  ngOnInit() {
    if(!this.formGroup)
    this.ShowAnyWay = true;
  }

  GetErrors() {
    var control = this.formGroup.get(this.fieldName);

    if (control.pristine || !control.errors) {
      return false;
    }
    else {
      return control.errors[this.errorName];
    }

  }

}
