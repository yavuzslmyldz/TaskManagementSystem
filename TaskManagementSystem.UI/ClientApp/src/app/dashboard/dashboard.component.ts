import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from "@angular/router";
import { Duty } from '../app-model/duty.model';
import { TaskService } from '../app-service/task.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  providers: [TaskService]
})
export class DashboardComponent {
  public tasks: Duty[] = [];
  displayedColumns: string[] = ['requiredByDate', 'description', 'status', 'type', 'assigned', 'nextActionDate'];

  displayedColumnsStruct = [
    { name: 'Required By Date', value: 'requiredByDate', type: 'date' },
    { name: 'Description', value: 'description', type: 'string' },
    { name: 'Status', value: 'status', type: 'string' },
    { name: 'Type', value: 'type', type: 'string' },
    { name: 'Assigned', value: 'assigned', type: 'string' },
    { name: 'Next Action Date', value: 'nextActionDate', type: 'date' },
  ];
  dataSource: MatTableDataSource<Duty> = new MatTableDataSource<Duty>();


  constructor(private taskService: TaskService, private router: Router, private route: ActivatedRoute, private snackBar: MatSnackBar) {
    taskService.getAll().subscribe(result => {
      this.tasks = result;
      this.createTable();
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
  }

  createTable() {
    this.dataSource = new MatTableDataSource(this.tasks);
  }

  showDetail(row: Duty) {
    this.router.navigate(['/edit-task', row.id]);
  }

}


