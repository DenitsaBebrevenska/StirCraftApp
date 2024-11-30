export type RecipeCook = {
    id: number;
    name: string;
    mainImageUrl: string;
    difficultyLevel: string;
    rating: number;
    likes: number;
    categories: string[];
    isAdminApproved: boolean;
}