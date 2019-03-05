import { Comment} from './comment'

export class Answer {
    public Id: number;
    public Value: string;
    public Description: string;
    public QuestionId: number;
    public CreatedDate: Date;
    public UpVote: number;
    public DownVote: number;
    public Comments: Comment[];

    constructor () {
      
    }
  }