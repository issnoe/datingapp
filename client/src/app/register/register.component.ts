import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  registerForm: FormGroup;

  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
        Validators.maxLength(8),
      ]),
      confirmPassword: new FormControl('', [
        Validators.required,
        this.machValues('password'),
      ]),
    });
  }

  machValues(matchTo: string): ValidatorFn {
    // Take a look the return value beacuse if will be use por show the errors
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value
        ? null
        : { isMatching: true };
    };
  }

  register() {
    // To get the content of the form this.registerForm.value
    // this.accountService.register(this.model).subscribe(
    //   (response) => {
    //     console.log(response);
    //     this.cancel();
    //   },
    //   (error) => {
    //     console.log(error);
    //   }
    // );
  }

  cancel() {
    this.cancelRegister.emit(false);
  }
}
