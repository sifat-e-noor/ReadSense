import Head from 'next/head';
import * as React from 'react';
import Stack from '@mui/material/Stack';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import BasicButtons from '../components/button';
import pickstory from '../styles/pickstory.module.css';
import styles from '../components/button.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import Link from 'next/link';
import BookCoverImage from '../components/bookCoverImage';
import { Icon } from '@mui/material';
import { ArrowBackIosNewRounded, BackHandRounded } from '@mui/icons-material';

export default function newUserPickStory() {
    const [selectBookId, setSelectBookId] = React.useState(undefined);


    const availableBooks = [
        {bookId: 1, src: "/images/Book_sample1.png"},
        {bookId: 2, src: "/images/Book_sample1.png"},
        {bookId: 3, src: "/images/Book_sample1.png"},
        {bookId: 4, src: "/images/Book_sample1.png"},
        {bookId: 5, src: "/images/Book_sample1.png"},
        {bookId: 6, src: "/images/Book_sample1.png"},
        {bookId: 7, src: "/images/Book_sample1.png"},
        {bookId: 8, src: "/images/Book_sample1.png"},
        {bookId: 9, src: "/images/Book_sample1.png"},
        {bookId: 10, src: "/images/Book_sample1.png"},
        {bookId: 11, src: "/images/Book_sample1.png"},
    ]

    return (
      <>
        <div className={pickstory.container} >
          <div className={pickstory.columnLeft}>
            <div className={pickstory.columnLeftUpper}>
              <div className={pickstory.columnRightHeader}>
                <Stack spacing={2} direction="row">
                  <IconButton edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
                    <ArrowBackIosNewRounded sx={{ color: '#735BF2'}}/>
                  </IconButton>
                  <p>Back</p> 
                </Stack>  
              </div>
              <section className={utilStyles.headingXl}> 
              <p>Great!<br/> 
              Pick your story & start reading!</p>
              </section> 
              <section className={utilStyles.headingMd} > 
                  <p>All you have to do is read a story you like!</p>
              </section> 
              <div className={pickstory.columnLeftUpperMiddle1}>
                    {
                        availableBooks.map((book) => {
                            return (
                                <BookCoverImage 
                                    src={book.src}
                                    bookId={book.bookId}
                                    selected={selectBookId === book.bookId}
                                    handleClick={setSelectBookId}
                                    key={book.bookId}
                                />
                            )
                        })
                    }
                </div>
                <p style={{color:'gray', textAlign:'center', fontStyle: 'italic'}}>choose any</p>
            </div>
            <div className={pickstory.columnLeftLower}>   
            <Stack alignItems='center' direction="row">
                <Button variant="contained" className={styles.buttonFilled}>Let's read!</Button>
            </Stack>
            </div>
          </div>
          <div className={pickstory.columnRight}>
            <div className={pickstory.columnRightInner}>
            {/* <div style={{flex: 1, display: 'flex', flexDirection: 'row', backgroundColor: 'red', justifyContent: 'flex-end', alignItems: "center" }}> */}
            <Image
              src="/images/pickStory.png"
              width={0}
              height={0}
              sizes="100vw"
              style={{ width: 'auto', height: 'auto'}} // optional
            /> 
            </div>
          </div>
        </div>
     </>
    );
  }





{/* <Stack spacing={2} direction="column" className={utilStyles.headingMd}> */}
{/* <div className={pickstory.columnLeftUpperMiddle1}> */}
{/* <Stack spacing={4} direction="row" justifyContent='center' wrap='wrap' sx={{ maxWidth: '50%' }} className={utilStyles.headingMd}> */}
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     />
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage 
//         src="/images/Book_sample1.png"
//     /> 
//     <BookCoverImage
//         src="/images/Book_sample1.png"
//     />
// </div>
{/* </Stack> */}
{/* <div className={pickstory.columnLeftLowerMiddle2}> */}
{/* <Stack spacing={4} direction="row" justifyContent='center' className={utilStyles.headingMd}> */}
{/* <BookCoverImage 
        src="/images/Book_sample1.png"
    />
    <BookCoverImage 
        src="/images/Book_sample1.png"
    />  */}
{/* </div> */}
{/* </Stack> */}
{/* <p style={{color:'gray', textAlign:'center', fontStyle: 'italic'}}>choose any</p> */}
{/* </Stack> */}