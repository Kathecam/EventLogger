import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/components/header/header.component';
import { EventLoggerService } from '../../shared/services/EventLogger.service';
import { EventLog } from '../../shared/interfaces/EventLog';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-event-logger',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './EventLogger.component.html',
  styleUrl: './EventLogger.component.css',
})
export class EventLoggerComponent {

  dataEvent: EventLog[] = [];
  filterDataEvent: EventLog[] = [];

  constructor(
    private eventLoggerService: EventLoggerService,
    private router: Router,
    private formBuilder: FormBuilder,
  ) {
    this.buildForm();
    this.getAll();
  }

  form!: FormGroup;

  buildForm() {
    this.form = this.formBuilder.group({
      startDate: [''],
      endDate: [''],
      typeEvent: [''],
    })
  }

  search() {
    if(!this.startDate && !this.endDate && !this.typeEvent) {
      this.getAll();
      return;
    }

    if((!this.startDate || !this.endDate) && !this.typeEvent) {
      alert("Para filtrar con fechas ambas fechas deben de estar rellenas");
      return;
    }

    if(this.typeEvent && !this.startDate && !this.endDate) {
      this.filterDataEvent = this.dataEvent.filter(event => event.typeEvent === this.typeEvent);
      return;
    }

    if(this.startDate && this.endDate) {
      this.eventLoggerService.search(this.startDate,this.endDate).subscribe({
        next: (data: EventLog[]) => {
          this.filterDataEvent = data;
          if(this.typeEvent) {
            this.filterDataEvent = this.dataEvent.filter(event => event.typeEvent === this.typeEvent);
          }
        },
        error: error => {
          console.log(error);
        }
      })
    }
  }

  getAll() {
    this.eventLoggerService.getAll().subscribe({
      next: (data: EventLog[]) => {
        this.dataEvent = data;
        this.filterDataEvent = data;
      },
      error: error => {
        console.log(error);
      }
    });
  }

  goToForm() {
    this.router.navigate(['eventForm']);
  }

  get typeEvent() { return this.form.get('typeEvent')?.value; }
  get startDate() { return this.form.get('startDate')?.value; }
  get endDate() { return this.form.get('endDate')?.value; }
}
