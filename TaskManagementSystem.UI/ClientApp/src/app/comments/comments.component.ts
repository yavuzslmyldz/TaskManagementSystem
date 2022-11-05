import { Component, Input } from "@angular/core";
import { Comment } from '../app-model/comment.model';
import FuzzySearch from "fuzzy-search";
import { CommentService } from '../app-service/comment.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.scss'],
  providers: [CommentService]
})

export class CommentsComponent {
  comments: Comment[] = [];
  @Input() taskId = 0;

  constructor(private commentService: CommentService, private snackBar: MatSnackBar) {
   
  }

  ngOnInit() {
    let _params = { 'taskId': this.taskId }
    this.commentService.getAll(_params).subscribe(result => {
      this.comments = result;
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
  }



  searchText: string = "";
  result: Comment[] = []
  isEditMode: boolean = false;

  selectComment(comment: Comment) {
    console.log("Selected comment code object: ", comment);
  }

  searcher = new FuzzySearch(this.comments, ["commentText"], {
    caseSensitive: false
  });

  addComment() {
    this.isEditMode = true;
  }

  refresh() {
    let _params = { 'taskId': this.taskId }
    this.isEditMode = false;
    this.commentService.getAll(_params).subscribe(result => {
      this.comments = result;
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 
  }

  async deleteComment(id: number) {

    await this.commentService.delete({ 'id': id.toString() }).subscribe(() => {
      this.snackBar.open('Comment Successfully Added.');
    }, error => { console.error(error); this.snackBar.open('Opps! Shomething went wrong.'); }); 

  }

  cancelComment() {
    this.isEditMode = false;
  }

  onSearchText() {
    this.result = this.searcher.search(this.searchText);
    console.log(this.searchText, ": ", this.result);
  }


}



