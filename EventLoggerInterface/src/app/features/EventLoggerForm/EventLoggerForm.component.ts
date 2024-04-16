import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/components/header/header.component';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { EventLog } from '../../shared/interfaces/EventLog';
import { EventLoggerService } from '../../shared/services/EventLogger.service';

@Component({
  selector: 'app-event-logger-form',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './EventLoggerForm.component.html',
  styleUrl: './EventLoggerForm.component.css',
})
export class EventLoggerFormComponent {

  form!: FormGroup;

  constructor(
    private router: Router,
    private formBuilder: FormBuilder,
    private eventLoggerService: EventLoggerService
  ) {
    this.buildForm()
  }

  buildForm() {
    this.form = this.formBuilder.group({
      typeEvent: ['', Validators.required],
      description: ['', Validators.required],
    })
  }

  save() {
    if(!this.form.valid) {
      alert("Todos los campos deben estar llenos");
    }

    let data: EventLog = this.form.value;
        data.eventLogId = 0;
        data.dateTime = new Date();
    
    this.eventLoggerService.create(data).subscribe({
      next: () => {
        alert("Log creado con exito");
        this.router.navigate(['/home']);
      },
      error: error => {
        alert("Se ha producido un erro contactese con su administrador");
        console.log(error);
      },
      complete: () => {
        console.log('complete');
      }
    })
    
  }

  goToBack(): void {
    this.router.navigate(['/home']);
  }
}
