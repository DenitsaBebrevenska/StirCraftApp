import { RecipeCommentReply } from "./recipeCommentReply";

export type RecipeComment = {
    id: number;
    userDisplayName: string;
    title: string;
    body: string;
    replies: RecipeCommentReply[];
}