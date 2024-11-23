export type RecipeShort = {
    id: number;
    name: string;
    difficultyLevel: string;
    mainImageUrl?: string | null;
    cookName: string;
    rating: number;
    likes: number;
    categories: string[];
}