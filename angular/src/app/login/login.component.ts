import { Component } from '@angular/core';
import { CardModule } from 'primeng/card';
import { FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { FloatLabelModule } from 'primeng/floatlabel';
import { ButtonModule } from 'primeng/button';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [ CardModule, InputTextModule, FloatLabelModule, ButtonModule ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  router: Router;

  constructor(router: Router) {
    this.router = router;
  }

  loginForm = new FormGroup({
    email: new FormControl<string>("", { validators: Validators.required }),
    password: new FormControl<string>("", { validators: Validators.required })
  });

  login() {
    // TODO implement authentication logic
    
    this.router.navigate(["/home"]);
  }

}
