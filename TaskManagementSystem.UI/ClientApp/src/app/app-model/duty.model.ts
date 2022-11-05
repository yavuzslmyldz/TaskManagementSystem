export interface Duty {
  id: number;
  requiredByDate: Date;
  description: string;
  status: string;
  type: string;
  assigned?: string;
  nextActionDate?: Date;
  createdDate: Date;
}
