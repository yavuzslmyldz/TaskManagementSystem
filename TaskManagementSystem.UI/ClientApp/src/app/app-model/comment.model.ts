export interface Comment {
  id: number;
  taskId: number;
  commentText: string;
  commentType: string;
  remainderDate?: Date
  createdDate: Date;
}
