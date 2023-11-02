import { createSlice } from  "@reduxjs/toolkit";
import { AppState } from "./store";

export interface ReaderState {
    fontSize: number;
    fonts: string;
    lineHeight: number;
    lineSpacing: number;
    align: string;
    layout: string;
}

const initialState: ReaderState = {
    fontSize: 18,
    fonts: "serif",
    lineHeight: 20,
    lineSpacing: 0.1,
    align: "left",
    layout: "row",
};

export const readerSlice = createSlice({
    name: "reader",
    initialState,
    reducers: {
        setFontSize(state, action) {
            state.fontSize = action.payload;
        }, 
        setFonts(state, action) {
            state.fonts = action.payload;
        },
        setLineHeight(state, action) {
            state.lineHeight = action.payload;
        },
        setLineSpacing(state, action) {
            state.lineSpacing = action.payload;
        },
        setAlign(state, action) {
            state.align = action.payload;
        },
        setLayout(state, action) {
            state.layout = action.payload;
        },
    }
});

export const { setFontSize, setFonts, setLineHeight, setLineSpacing, setAlign, setLayout } = readerSlice.actions;

export const getFontSize = (state: AppState) => state.reader.fontSize;
export const getFonts = (state: AppState) => state.reader.fonts;
export const getLineHeight = (state: AppState) => state.reader.lineHeight;
export const getLineSpacing = (state: AppState) => state.reader.lineSpacing;
export const getAlign = (state: AppState) => state.reader.align;
export const getLayout = (state: AppState) => state.reader.layout;

export default readerSlice.reducer;