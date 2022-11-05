import { Component } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { formatDate } from '@angular/common';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { taskStatuses, taskAssigns, taskTypes } from '../../app-const/dummy.const';
import { TaskService } from '../../app-service/task.service';

@Component({
  selector: 'app-task-editor',
  templateUrl: './task-editor.component.html',
  styleUrls: ['./task-editor.component.scss'],
  providers: [TaskService]
})
export class TaskEditorComponent {

  constructor(private route: ActivatedRoute, private fb: FormBuilder, private snackBar: MatSnackBar, private router: Router, private taskService: TaskService ) {

  }

  id: number = 0;
  task: any;
  statuses = taskStatuses;
  types = taskTypes;
  assigns = taskAssigns;

  taskForm = new FormGroup({
    requiredByDate: new FormControl(''),
    status: new FormControl(''),
    type: new FormControl(''),
    description: new FormControl(''),
    assigned: new FormControl(''),
    //id: new FormControl('')
  });

  ngOnInit() {
    let idParam = this.route.snapshot.paramMap.get('id');

    if (idParam != null)
    this.id = +idParam;

    if (this.id != 0) {
      let _params = { 'id': this.id }
      this.taskService.get(_params).subscribe(result => {
        if (result != null) {
          this.task = result;
          this.taskForm = this.fb.group({
            requiredByDate: [formatDate(this.task.requiredByDate, 'yyyy-MM-dd', 'en'), [Validators.required]],
            description: [this.task.description, [Validators.required, Validators.maxLength(500), Validators.minLength(10)]],
            status: [this.task.status, [Validators.required]],
            type: [this.task.type, [Validators.required]],
            assigned: [this.task.assigned],
            //id: [this.task.id]
          });
        }
      }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
    }
    else {
      this.snackBar.open('Opps! Shomething went wrong.');
      this.router.navigate(['/dashboard']);
    }
  }

  async update() {
    let formObj = this.taskForm.getRawValue();
    let serializedForm = JSON.stringify(formObj);
    this.taskService.update(serializedForm).subscribe(() => {
      this.snackBar.open('Task Successfully Updated.');
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
  }

  openDeleteDialog() {
    if (confirm("Are you sure to delete?")) {
      let _params = { 'id': +this.id }
      this.taskService.delete(_params).subscribe(result => {
        this.snackBar.open('Task successfully deleted.');
        this.router.navigate(['/dashboard']);
      }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
    }
  };

}

