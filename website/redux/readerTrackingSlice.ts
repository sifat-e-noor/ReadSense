import { createSlice } from  "@reduxjs/toolkit";
import { AppState } from "./store";

export interface ReaderTrackingState {
    scrollEvent: {
        scrollY: number, 
        time: number
    }[];
    scrollTrackingData: {
        start: number,
        end: number,
        startScrollY: number,
        endScrollY: number,
    }[];
}

const initialState: ReaderTrackingState = {
    scrollEvent: [],
    scrollTrackingData: [],
};

export const readerTrackingSlice = createSlice({
    name: "readerTracking",
    initialState,
    reducers: {
        setScrollEvent(state, action) {
            state.scrollEvent.push(action.payload) ;
        },
        setScrollTrackingData(state, action) {
            let scrollEvents = state.scrollEvent;
            state.scrollEvent = [];

            // Create tracking data for each scroll direction and add to state. 
            if(scrollEvents.length > 1) {
                let start = scrollEvents[0].time;
                let startScrollY = scrollEvents[0].scrollY;
                let direction = scrollEvents[1].scrollY - scrollEvents[0].scrollY ; // positive if scrolling down, negative if scrolling up
                let index = 1;
                while(index < scrollEvents.length ) {
                    while(index < scrollEvents.length  && (scrollEvents[index].scrollY - scrollEvents[index - 1].scrollY > 0) === (direction > 0) ) {
                        index++;
                    }
                    let end = scrollEvents[index-1].time;
                    let endScrollY = scrollEvents[index-1].scrollY;

                    if(start != end) {
                        state.scrollTrackingData.push({
                            start,
                            end,
                            startScrollY,
                            endScrollY,
                        });
                        start = end;
                        startScrollY = endScrollY;
                        direction *= -1;
                    }
                }
            }
        },
    },
});

export const { setScrollEvent, setScrollTrackingData } = readerTrackingSlice.actions;

export const selectScrollEvent = (state: AppState) => state.readerTracking.scrollEvent;
export const selectScrollTrackingData = (state: AppState) => state.readerTracking.scrollTrackingData;

export default readerTrackingSlice.reducer;