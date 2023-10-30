import Head from 'next/head';
import Layout, { siteTitle } from '../components/layout';
import utilStyles from '../styles/utils.module.css';
import BasicTextFields from '../components/textfield';
import landing from '../styles/landing.module.css';
import Button from '@mui/material/Button';
import Image from 'next/image';
import styles from '../components/button.module.css';
import Link from 'next/link';
import HTMLViewer from '../components/htmlBookViewer';
import { useRouter } from 'next/router';

export default function Home(props) {
  const router = useRouter();
  const { bookContent } = router.query;


  return (
    <Layout home>
      <Head>
        <title>{siteTitle}</title>
      </Head>
      <section className={utilStyles.bookText}>
        <div>
          <HTMLViewer src={bookContent} />
        </div>
      </section>
    </Layout>
  );
}