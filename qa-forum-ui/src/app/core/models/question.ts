import { Comment} from './comment'

export class Question {
  public Id: number;
  public Value: string;
  public Description: string;
  public UserId?: any;
  public CreatedDate: Date;
  public UpVote: number;
  public DownVote: number;
  public Comments: Comment[];

  constructor () {
    
  }
}