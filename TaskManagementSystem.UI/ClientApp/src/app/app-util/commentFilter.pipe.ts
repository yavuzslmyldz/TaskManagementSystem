import { Pipe, PipeTransform } from '@angular/core';
import { Comment } from '../app-model/comment.model';
@Pipe({
  name: 'filter'
})
export class CommentFilterPipe implements PipeTransform {
  transform(items: Comment[], searchText: string): Comment[] {
    if (!items) return [];
    if (!searchText) return items;
    searchText = searchText.toLowerCase();
    return items.filter(code => {
      return code.commentText.toLowerCase().includes(searchText);
    });
  }
}
