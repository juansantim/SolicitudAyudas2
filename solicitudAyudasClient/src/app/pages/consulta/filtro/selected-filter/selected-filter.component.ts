import { Component, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, ValidatorFn } from '@angular/forms';

@Component({
  selector: 'app-selected-filter',
  templateUrl: './selected-filter.component.html',
  styleUrls: ['./selected-filter.component.css']
})
export class SelectedFilterComponent implements OnInit {

  @Input()
  name: string;

  @Input()
  control: FormControl;

  @Input()
  format:string;

  constructor() { }
  

  ngOnInit() {
  }

  // forbiddenNameValidator(nameRe: RegExp): ValidatorFn {
  //   return (control: AbstractControl): { [key: string]: any } | null => {

  //     const forbidden = nameRe.test(control.value);

  //     return forbidden ? { forbiddenName: { value: control.value } } : null;
  //   };
  // }
}
