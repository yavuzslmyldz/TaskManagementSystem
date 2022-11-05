import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from "@angular/router";
import { taskStatuses, taskAssigns, taskTypes } from '../../app-const/dummy.const';
import { TaskService } from '../../app-service/task.service';


@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.scss'],
  providers: [TaskService]
})
export class TaskFormComponent {

  constructor(private fb: FormBuilder, private snackBar: MatSnackBar, private router: Router, private taskService: TaskService) {

  }

  statuses = taskStatuses;
  types = taskTypes;
  assigns = taskAssigns;
  minRequiredByDate = new Date;


  taskForm = new FormGroup({
    requiredByDate: new FormControl(''),
    status: new FormControl(''),
    type: new FormControl(''),
    description: new FormControl(''),
    assigned: new FormControl(''),
  });

  ngOnInit() {
    this.taskForm = this.fb.group({
      requiredByDate: ['', [Validators.required]],
      description: ['', [Validators.required, Validators.maxLength(500), Validators.minLength(10)]],
      status: ['', [Validators.required]],
      type: ['', [Validators.required]],
      assigned: ['']
    });

  }

  async create() {
    let formObj = this.taskForm.getRawValue();
    let serializedForm = JSON.stringify(formObj);
    await this.taskService.create(serializedForm).subscribe(() => {
      this.snackBar.open('Task Successfully Created.');
      this.router.navigate(['/dashboard']);
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
  }
}

