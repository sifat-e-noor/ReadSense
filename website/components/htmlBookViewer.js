// components/BookViewer.js
"use client";
import { useEffect, useState } from 'react';

const HTMLViewer = () => {
  const [htmlContent, setHTMLContent] = useState('');

  useEffect(() => {
    fetch('/books/TheLittlePrince.html')
      .then((response) => response.text())
      .then((data) => {
        setHTMLContent(data);
      })
      .catch((error) => {
        console.error('Error loading the book:', error);
      });
  }, []);

  return (
    <div
      style={{
        fontFamily: 'Georgia, serif',
        fontSize: '1.2rem',
        lineHeight: '1.5',
        letterSpacing: '0.01rem',
        textAlign: 'justify',
        backgroundColor: 'white',
        // margin: '4rem auto',
        marginLeft: '15%',
        marginRight: '10%',
      }}
      dangerouslySetInnerHTML={{ __html: htmlContent }}
    />
  );
};

export default HTMLViewer;
