import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from "@angular/router";
import { commentTypes } from '../app-const/dummy.const';
import { CommentService } from '../app-service/comment.service';


@Component({
  selector: 'app-comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss'],
  providers: [CommentService]
})
export class CommentFormComponent {

  constructor(private fb: FormBuilder, private snackBar: MatSnackBar, private router: Router, private commentService: CommentService) {

  }

  @Input() taskId = 0;
  @Output() createCommentEmitter = new EventEmitter<void>();

  comment: any;
  types = commentTypes;


  commentForm = new FormGroup({
    commentText: new FormControl(''),
    commentType: new FormControl(''),
    remainderDate: new FormControl(''),
    taskId: new FormControl('')
  });


  ngOnInit() {
    this.commentForm = this.fb.group({
      commentText: ['', [Validators.required, Validators.maxLength(500), Validators.minLength(10)]],
      commentType: ['', [Validators.required]],
      remainderDate: [''],
      taskId: ['']
    });

    this.commentForm.controls.taskId.setValue(this.taskId.toString());
  }

  async create() {
    let formObj = this.commentForm.getRawValue();
    let serializedForm = JSON.stringify(formObj);

    await this.commentService.create(serializedForm).subscribe(() => {
      this.snackBar.open('Comment Successfully Added.');
      this.createCommentEmitter.emit();
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); });
  }
}

